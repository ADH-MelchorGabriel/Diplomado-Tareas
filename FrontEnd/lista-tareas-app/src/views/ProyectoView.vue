<template>
  <app-layout>
    <div class="d-flex justify-content-between align-items-center mb-4">
      <div>
        <h1 class="mb-1">Lista de proyectos</h1>
        <p>Administracion de proyectos</p>
      </div>
      <button class="btn btn-primary">Nuevo proyecto</button>
    </div>

    <div v-if="loading">
      <div class="spinner-border text-primary"></div>
      <p>Cargando...</p>
    </div>

    <div v-if="error" class="alert alert-danger">
      {{ error }}
    </div>

    <div class="card-body">
      <table class="table table-hover align-middle">
        <thead class="table-light">
          <tr>
            <th>ID</th>
            <th>Nombre</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="proyecto in proyectos" :key="proyecto.idProyecto">
            <td>{{ proyecto.idProyecto }}</td>
            <td>{{ proyecto.nombre }}</td>
            <td>
              <button class="btn btn-warning">Editar</button>
              <button class="btn btn-danger">Eliminar</button>
            </td>
          </tr>
        </tbody>
      </table>
    </div>
    <div v-if="!loading && proyectos.length === 0" class="alert alert-info">
      No hay proyectos registrados
    </div>
  </app-layout>
</template>

<script setup>
import { ref, onMounted } from "vue";
import AppLayout from "../components/layout/AppLayout.vue";
import { getProyectos } from "../services/proyectoService";

const proyectos = ref([]);
const loading = ref(false);
const error = ref("");

const cargarDatos = async () => {
  try {
    loading.value = true;

    error.value = null;

    const data = await getProyectos();

    proyectos.value = data;
    loading.value = false;

    console.log(data);
  } catch (error) {
    loading.value = false;
    error.value = error.message;
    console.log(error);
  } finally {
    loading.value = false;
  }
};

onMounted(() => {
  cargarDatos();
});
</script>
