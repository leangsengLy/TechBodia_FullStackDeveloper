<template>
    <div class="flex flex-col items-center justify-center gap-4">
        <img :src="image" alt="empty notes" class="w-[150px] h-[150px] object-contain"/>
        <h3 class="font-bold text-[20px]">You don't have any notes yet.</h3>
        <div class="text-center text-[#05050583]">
            <p>Start typing your note below, use the blocker checkbox</p>
            <p>to convert your notes into to do's.</p>
        </div>
    </div>
</template>

<script lang="ts" setup>
import image from '../assets/corrupted.png'
</script>

<style lang="scss" scoped>

</style>