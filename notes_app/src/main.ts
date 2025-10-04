import { createApp } from 'vue'
import './main.css' 
import router from './route/index.ts'
import { createPinia } from 'pinia'
import App from './App.vue'
import PrimeVue from 'primevue/config';

// PrimeVue CSS
import 'primevue/resources/themes/lara-light-indigo/theme.css'; // or any existing theme
import 'primevue/resources/primevue.min.css';
import 'primeicons/primeicons.css';

// import 'primevue/resources/themes/aura-light-green/theme.css'
createApp(App).use(createPinia()).use(PrimeVue).use(router).mount('#app')
