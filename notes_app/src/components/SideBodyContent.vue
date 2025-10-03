<template>
    <div class="flex justify-center items-center">
        <EmptyNotes/>
    </div>
</template>

<script lang="ts" setup>
import { useCounterStore } from '../store/counter';
import EmptyNotes from './EmptyNotes.vue';
const count = useCounterStore();
   
</script>

<style lang="scss" scoped>

</style>