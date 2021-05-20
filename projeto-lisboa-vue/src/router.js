import Vue from 'vue'
import Router from 'vue-router'
import ListView from './views/ListView'
import UploadView from './views/UploadView'


Vue.use(Router)

export default new Router({
    mode: 'hash',
    routes: [
    {
        path: '/',
        component: ListView
    },
    {
        path: '/upload',
        component: UploadView
    }]
})