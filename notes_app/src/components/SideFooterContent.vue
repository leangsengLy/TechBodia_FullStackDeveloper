<template>
    <div class=" px-[25px] py-[20px]">
        <div class="w-full h-full bg-[#9696961f] rounded-[10px] flex items-center justify-center" >
            <input type="text" :readonly="content.title==''" placeholder="Type something..."  :class="[content.title!=='' ? 'cursor-text' : 'cursor-not-allowed']" class="w-full h-full  bg-[#dfdfdf00] outline-none rounded-[10px] px-4"/>
        </div>
    </div>
</template>

<script lang="ts" setup>
import { useContentStore } from '../store/content';


   const content = useContentStore();
</script>

<style lang="scss" scoped>

</style>