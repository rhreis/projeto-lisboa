import Vue from 'vue';
import axios from 'axios'

//axios.defaults.baseURL = 'http://localhost:5000/api/'
//axios.defaults.headers.common['Access-Control-Allow-Origin'] = '*'

Vue.use({
    install(Vue) {
        Vue.prototype.$http = axios.create({
            baseURL: 'http://localhost:5000/api/',
            headers: {
                'Access-Control-Allow-Origin': '*'
            }
        })
    }
})
