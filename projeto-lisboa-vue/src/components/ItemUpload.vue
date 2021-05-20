<template>
  <v-container>
    <v-row
      justify="space-around"
      align="center"
    >

    <v-card
      elevation=""
      outlined
      shaped    
    >
      <v-card-title><strong>{{item.name}}</strong></v-card-title>
      <v-divider class="mx-4"></v-divider>
      <v-card-text>

      <v-row>
        <v-col
          v-for="shape in shapePattern" :key="shape.name"
        >
          <v-card-text><strong>{{shape.name}}</strong></v-card-text>

          <v-container v-for="metal in metalPatter" :key="metal.name">
            <div class="text-center">
              <v-container v-if="hasPhoto(shape.name, metal.name)">
                <v-chip
                  class="ma-2"                
                  text-color="white"
                  color="green"
                  @click="deletePhoto(item, shape.name, metal.name)"
                >
                  {{ metal.name }}
                  <v-icon right>mdi-close-circle</v-icon>
                </v-chip>
              </v-container>
              <v-container v-else>
                <v-chip
                  class="ma-2"                
                  text-color="white"
                  color="blue-grey lighten-3"
                  @click="selectPhoto(item, shape.name, metal.name)"
                >
                  {{ metal.name }}
                  <v-icon right>mdi-cloud-upload</v-icon>
                </v-chip>
                <input style="display: box" type="file" ref="fileInput" @change="onFileSelected">
              </v-container>
            </div>
          </v-container>
          <v-divider class="mx-4"></v-divider>
        </v-col>
      </v-row>
      </v-card-text>
    </v-card>
    </v-row>
  </v-container>  
</template>

<script>
export default{
    components: {
      
    },
    props: {
        item: null
    },
    created: function() {
      this.getPhotoProperties()
      this.processPhotos()
    },
    data() {
        return {
            metalPatter: [
              { name: 'Yellow Gold' },
              { name: 'White Gold' },
              { name: 'Rose Gold' },
              { name: 'Platinum' }
              ],
            shapePattern: [
              { name: 'Round' },
              { name: 'Cushion' },
              { name: 'Princess' }
            ],
            photoProperties: [],
            itemList: []
        }
    },
    methods: {
      getPhotoProperties() {
        if (this.item != null) {
          this.item.itemPhotos.forEach(p => {
            var metal = ''
            var shape = ''
            p.itemPhotoPropertySet.forEach(s => {
              if (s.propertyId == 1) {
                metal = s.value
              } else if (s.propertyId == 2) {
                shape = s.value
              }              
            })
            this.photoProperties.push({metal: metal, shape: shape})
          });
        }
      },
      hasPhoto(shape, metal) {
        var result = this.photoProperties.filter(p => {
          return p.metal == metal && p.shape == shape
        })
        return result.length
      },
      processPhotos() {        
        const getMetal = p => p.propertyId === 1
        const getShape = p => p.propertyId === 2
        let it = {}

        if (this.item == null)
            return

        it['itemId'] = this.item.id

        this.item.itemPhotos.forEach(i => {
            it['id'] = i.id
            it['name'] = i.name
            it['original'] = i

            let m = i.itemPhotoPropertySet.filter(getMetal)
            let s = i.itemPhotoPropertySet.filter(getShape)
            
            it['fileName'] = i.fileName
            it['metal'] = m[0].value
            it['shape'] = s[0].value

            this.itemList.push(it)
          });          
      },
      deletePhoto(item, shape, metal) {
        var id = 0
        this.item.itemPhotos.forEach(i => {
          var m = ''
          var s = ''
            
          i.itemPhotoPropertySet.forEach(p => {
            console.log(p.propertyId, p.value)
            
            if (p.propertyId == 1)
              m = p.value
            else if (p.propertyId == 1)
              s = p.value
          })

          console.log(id, m, s)
          
          if (m == metal && s == shape)
            id = i.id
          });

        this.$http.delete('ItemPhotos', id)
          .then(res => {
              this.items = res.data
              this.processPhotos(res.data)
          })
      },
      selectPhoto(item, shape, metal) {
        if (this.selectedFile.name == '')
          return

        let ext = this.selectedFile.name.split('.').pop();
        let fileName = `${this.itemList[0].itemId}-${shape}-${metal}.${ext}`
        
        var data = {
          itemId: this.itemList[0].itemId,
          typeId: 1,
          fileName: fileName,
          position: 0,
          alt: null,
          isActive: true,
          itemPhotoPropertySet: [{
              propertyId: 1,
              value: metal
          }, {
              propertyId: 2,
              value: shape
          }],          
        }

        this.$http.post('ItemPhotos', data, {
           headers: {
              'Content-Type': 'application/json'
            }
        })
        .then(() => {            
            // UPLOAD FILE AFTER SAVE ITEM PHOTO
            const fd = new FormData();
            fd.append('file', this.selectedFile, fileName)

            this.$http.post('ItemPhotos/upload', fd, {
              headers: {
                  'Content-Type': 'multipart/form-data'
                }
            })
            .then(res => {
                alert('Success!', res.data)
                this.processPhotos()
            })

            this.getPhotoProperties()
            this.processPhotos()
            this.$route.push('/upload')
        })
      },
      onFileSelected(e) {
        this.selectedFile = e.target.files[0]
      }
    }
}
</script>

<style scoped>

</style>>
   
