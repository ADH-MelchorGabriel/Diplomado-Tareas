<template>
  <app-layout>
    <div class="d-flex justify-content-between align-items-center mb-4">
      <div>
        <h1 class="mb-1">Lista de proyectos</h1>
        <p>Administracion de proyectos</p>
      </div>
    </div>

    <proyecto-form @guardando="cargarDatos" />

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
              <button class="btn btn-warning" @click="editarProyecto(proyecto)">
                Editar
              </button>
              <button
                class="btn btn-danger"
                @click="borrarProyecto(proyecto.idProyecto)"
              >
                Eliminar
              </button>
            </td>
          </tr>
        </tbody>
      </table>
    </div>
    <div v-if="!loading && proyectos.length === 0" class="alert alert-info">
      No hay proyectos registrados
    </div>
  </app-layout>

  <ProyectoEditModal
    :proyecto="proyectoSeleccionado"
    @actualizando="cargarDatos"
  />
</template>

<script setup>
import { ref, onMounted } from "vue";
import AppLayout from "../components/layout/AppLayout.vue";
import { getProyectos, deleteProyecto } from "../services/proyectoService";
import ProyectoForm from "../components/ProyectoForm.vue";
import Swall from "sweetalert2";

import ProyectoEditModal from "../components/ProyectoEditModal.vue";
import * as bootstrap from "bootstrap";

const proyectos = ref([]);
const loading = ref(false);
const error = ref("");
const proyectoSeleccionado = ref({});

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

const editarProyecto = (proyecto) => {
  proyectoSeleccionado.value = proyecto;
  const modalElement = document.getElementById("editarModal");
  const modal = new bootstrap.Modal(modalElement);
  modal.show();
};

const borrarProyecto = async (id) => {
  const resultado = await Swall.fire({
    title: "¿Elimiar Proyecto?",
    text: "Esta accion no se puede deshacer",
    icon: "warning",
    showCancelButton: true,
    confirmButtonText: "Si, Eliminar",
    cancelButtonText: "Cancelar",
  });

  if (!resultado.isConfirmed) {
    return;
  }
  try {
    await deleteProyecto(id);

    await Swall.fire({
      title: "Proyecto Eliminado",
      icon: "success",
      text: "El proyecto fue eliminado correctamente",
    });

    cargarDatos();
  } catch (error) {
    console.log(error);
    alert(error);
  }
};

onMounted(() => {
  cargarDatos();
});
</script>
