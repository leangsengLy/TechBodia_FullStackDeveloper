<script setup lang="ts">

</script>

<template>
  <div class=" mx-auto">
    <!-- <nav class="p-4 bg-gray-100">
      <router-link to="/" class="mr-4">Home</router-link>
      <router-link to="/notes">Notes</router-link>
    </nav> -->
    <router-view /> <!-- This is where pages render -->
  </div>
</template>

<style scoped>
.logo {
  height: 6em;
  padding: 1.5em;
  will-change: filter;
  transition: filter 300ms;
}
.logo:hover {
  filter: drop-shadow(0 0 2em #646cffaa);
}
.logo.vue:hover {
  filter: drop-shadow(0 0 2em #42b883aa);
}
</style>
