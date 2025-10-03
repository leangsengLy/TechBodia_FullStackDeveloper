import { createApp } from 'vue'
import './main.css' 
import router from './route/index.ts'
import { createPinia } from 'pinia'
import App from './App.vue'
createApp(App).use(createPinia()).use(router).mount('#app')
