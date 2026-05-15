<template>
  <div class="sidebar p-3">
    <h5 class="text-white mb-4">Menú</h5>
    <div class="nav flex-column">
      <router-link to="/" class="nav-link text-white"> Home </router-link>
      <router-link to="/proyecto" class="nav-link text-white">
        Proyectos
      </router-link>
      <router-link to="/empleado" class="nav-link text-white">
        Empleados
      </router-link>
      <router-link to="/tarea" class="nav-link text-white">
        Tareas
      </router-link>
      <router-link to="/about" class="nav-link text-white">
        Acerca de
      </router-link>
    </div>
  </div>
</template>

<script></script>

<style>
.sidebar {
  width: 250px;
  min-height: 100vh;
  background: #212529;
}

.nav-link {
  border-radius: 8px;
  margin-bottom: 5px;
  transition: 0.3s;
}

.nav-link:hover {
  background: rgba(255, 255, 255, 0.1);
}
.router-link-active {
  background: #0d6efd;
}
</style>
