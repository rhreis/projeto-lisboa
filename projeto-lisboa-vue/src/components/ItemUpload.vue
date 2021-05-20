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
                  {{hasPhoto(shape.name, metal.name)}}
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
                  {{hasPhoto(shape.name, metal.name)}}
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
        var it = {}

        if (this.item == null)
            return

        it['itemId'] = this.item.id

        this.item.itemPhotos.forEach(i => {
            it['id'] = i.id
            it['name'] = i.name
            it['original'] = i

            var m = i.itemPhotoPropertySet.filter(getMetal)
            var s = i.itemPhotoPropertySet.filter(getShape)
            
            it['fileName'] = i.fileName
            it['metal'] = m[0].value
            it['shape'] = s[0].value

            this.itemList.push(it)
          });          
      },
      deletePhoto(item, shape, metal) {
        var result = this.itemList.filter(p => {
          return p.metal == metal && p.shape == shape
        })

        alert(`Delete ${item.name} | ${shape} | ${metal} | ${result}`)

        const fd = new FormData();
        fd.append('image', this.selectedFile, this.selectedFile.name)
        this.$http.delete('ItemPhotos', )
          .then(res => {
              this.items = res.data
              this.processPhotos(res.data)
          })
      },
      selectPhoto(item, shape, metal) {
        if (this.selectedFile.name == '')
          return

        var data = {
          itemId: this.itemList[0].itemId,
          typeId: 1,
          fileName: this.selectedFile.name,
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
        .then(res => {
            this.items = res.data
            this.getPhotoProperties()
            this.processPhotos()
            this.$route.push('/upload')
        })

        // const fd = new FormData();
        // fd.append('file', this.selectedFile, this.selectedFile.name)

        // // application/json
        // // multipart/form-data
        // this.$http.post('ItemPhotos/upload', data, {
        //    headers: {
        //       'Content-Type': 'multipart/form-data'
        //     }
        // })
        // .then(res => {
        //     this.items = res.data
        //     this.processPhotos(res.data)
        // })
        
      },
      onFileSelected(e) {
        this.selectedFile = e.target.files[0]
      }
    }
}
</script>

<style scoped>

</style>>
   
