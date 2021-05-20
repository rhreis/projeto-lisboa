<template>
    <v-container>
        <v-row justify="space-around" v-for="item in items" :key="item.id">
            <ItemUpload :item="item" />
        </v-row>
    </v-container>
</template>

<script>
import ItemUpload from '@/components/ItemUpload';

export default{
    components: {
        ItemUpload
    },
    data() {
        return {
            items: [],
            itemList: [],
        }
    },
    created() {
        this.$http.get('Item')
            .then(res => {
                this.items = res.data
                this.processPhotos(res.data)
            })
    },
    methods: {
        processPhotos(items) {
            const getMetal = p => p.propertyId === 1
            const getShape = p => p.propertyId === 2            

            if (items == null)
                return

            items.forEach(i => {
                var it = {}

                it['id'] = i.id
                it['name'] = i.name
                it['original'] = i

                if (i.itemPhotos != null) {
                    i.itemPhotos.forEach(p => {
                        var m = p.itemPhotoPropertySet.filter(getMetal)
                        var s = p.itemPhotoPropertySet.filter(getShape)
                        
                        it['fileName'] = p.fileName
                        it['metal'] = m[0].value
                        it['shape'] = s[0].value
                        
                        this.itemList.push(it)
                    })
                }
            })
        },
    },
}
</script>

<style scoped>

</style>