import { createRouter, createWebHistory } from "vue-router";

import HomeView from "../views/HomeView.vue";
import ProyectoView from "../views/ProyectoView.vue";
import AboutView from "../views/AboutView.vue";
import EmpleadoView from "../views/EmpleadoView.vue";
import TareaView from "../views/TareaView.vue";

const routes = [
  {
    path: "/",
    name: "home",
    component: HomeView,
  },
  {
    path: "/proyecto",
    name: "proyecto",
    component: ProyectoView,
  },
  {
    path: "/empleado",
    name: "empleado",
    component: EmpleadoView,
  },
  {
    path: "/tarea",
    name: "tarea",
    component: TareaView,
  },
  {
    path: "/about",
    name: "about",
    component: AboutView,
  },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;
