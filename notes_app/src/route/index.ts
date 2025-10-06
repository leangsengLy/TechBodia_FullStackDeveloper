import Login from '../pages/Login/Login.vue'
import Notes from '../pages/AppNotes/Notes.vue'
import type { RouteRecordRaw } from 'vue-router'
import { createRouter } from 'vue-router'
import { createWebHistory } from 'vue-router'
import NotFound from '../pages/NotFound/NotFound.vue'

// Define routes with types
const routes: Array<RouteRecordRaw> = [
  {
    path: '/',
    name: 'Home',
    component: Login
  },
  {
    path: '/login',
    name: 'login',
    component: Login
  },
  {
    path: '/note',
    name: 'notes',
    component: Notes
  },
  {
    path: '/:pathMatch(.*)',
    name: 'NotFound',
    component: NotFound
  }
]

const router = createRouter({
  history: createWebHistory(),
  routes
})

export default router
