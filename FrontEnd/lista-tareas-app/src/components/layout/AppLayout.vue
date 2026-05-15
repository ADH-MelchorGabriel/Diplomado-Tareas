<template>
  <div>
    <AppNavBar />
    <div class="d-flex">
      <AppSidebar />
      <main class="content p-4">
        <slot> </slot>
      </main>
    </div>
  </div>
</template>

<script setup>
import AppSidebar from "./AppSidebar.vue";
import AppNavBar from "./AppNavBar.vue";
</script>

<style scoped>
.content {
  width: 100%;
  min-height: 100vh;
  background: #f8f9fa;
}
</style>
