<template>
  <div class="modal fade" id="editarModal" tabindex="-1">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title">Editar proyecto</h5>
          <button
            type="button"
            class="btn-close"
            data-bs-dismiss="modal"
          ></button>
        </div>

        <div class="modal-body">
          <form @submit.prevent="actualizar">
            <div class="mb-3">
              <label for="nombre" class="form-label">Nombre</label>
              <input
                type="text"
                class="form-control"
                id="name"
                v-model="form.nombre"
                max="120"
                placeholder="Ingresa un nombre para el proyecto"
              />
            </div>
            <div class="d-flex justify-content-end">
              <button
                type="button"
                class="btn btn-secondary me-2"
                data-bs-dismiss="modal"
              >
                Cancelar
              </button>
              <button class="btn btn-primary" :disabled="loading">
                <span
                  v-if="loading"
                  class="spinner-boder spinner-boder-sm me-2"
                ></span>
                Guardar
              </button>
            </div>
          </form>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup>
import { ref, watch } from "vue";
import { updateProyecto } from "../services/proyectoService";
import * as bootstrap from "bootstrap";

const props = defineProps({
  proyecto: {
    type: Object,
    required: false,
    default: () => ({}),
  },
});

const loading = ref(false);
const emit = defineEmits(["actualizando"]);
const form = ref({
  idProyecto: null,
  nombre: "",
});

watch(
  () => props.proyecto,
  (nuevoProyecto) => {
    if (nuevoProyecto && Object.keys(nuevoProyecto).length > 0) {
      form.value = {
        idProyecto: nuevoProyecto.idProyecto,
        nombre: nuevoProyecto.nombre,
      };
    } else {
      form.value = {
        idProyecto: null,
        nombre: "",
      };
    }
  },
  { immediate: true },
);

const actualizar = async () => {
  try {
    if (!form.value.nombre) {
      alert("El nombre del proyecto es obligatorio");
      return;
    }

    loading.value = true;

    await updateProyecto(form.value.idProyecto, form.value);
    emit("actualizando");

    const modal = bootstrap.Modal.getInstance(
      document.getElementById("editarModal"),
    );
    modal.hide();
  } catch (error) {
    console.log(error);
    alert("Error al actualizar el proyecto");
  } finally {
    loading.value = false;
  }
};
</script>
