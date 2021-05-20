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
              
              
              <v-chip
                class="ma-2"
                text-color="white"
                :color="hasPhoto(shape.name, metal.name) ? 'green' : 'blue-grey lighten-3'"

                @click="selectItem(item, shape.name, metal.name)"
              >
                
                {{ metal.name }}
                {{hasPhoto(shape.name, metal.name)}}
              </v-chip>

              
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

        if (this.item == null)
            return
        
        

        this.item.itemPhotos.forEach(i => {
            var it = {}

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

      selectItem(item, shape, metal) {
        var result = this.itemList.filter(p => {
          return p.metal == metal && p.shape == shape
        })
        result
      
        this.$router.push({path: 'upload', params: { result }})

        //alert(`${item.name} | ${shape} | ${metal} | ${result}`)
      }      
    }
}
</script>

<style scoped>

</style>>
   
