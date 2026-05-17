<template>
  <div class="card shadow-sm boder-0 mb-4">
    <div class="card-body">
      <h4>Nuevo proyecto</h4>
      <form @submit.prevent="guardar">
        <div class="mb-3">
          <label for="name" class="form-label">Nombre</label>
          <input
            type="text"
            class="form-control"
            id="name"
            v-model="form.nombre"
            max="120"
            placeholder="Ingresa un nombre para el proyecto"
          />
        </div>
        <button class="btn btn-primary" :disabled="loading">
          <span
            v-if="loading"
            class="spinner-border spinner-border-sm me-2"
          ></span>
          Guardar
        </button>
      </form>
    </div>
  </div>
</template>

<script setup>
import { ref } from "vue";
import { createProyecto } from "../services/proyectoService";
import Swall from "sweetalert2";
const emit = defineEmits(["guardando"]);
const loading = ref(false);
const form = ref({
  nombre: "",
});
const lipiarFormulaio = () => {
  form.value = {
    nombre: "",
  };
};
const guardar = async () => {
  try {
    if (!form.value.nombre) {
       await Swall.fire({
      title: "Error captura de proyecto",
      icon: "warning",
      text: "El nombre del proyecto es obligatorio",
    });
  
      return;
    }
    loading.value = true;
    await createProyecto(form.value);
    emit("guardando");
    lipiarFormulaio();
  } catch (error) {
    console.log(error);
     await Swall.fire({
      title: "Error captura de proyecto",
      icon: "warning",
      text: error.message,
    });
      } finally {
    loading.value = false;
  }
};
</script>
