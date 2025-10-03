<template>
    <div class="h-[60px] w-full bg-[#f3f4f6] flex items-center justify-between px-6">
        <div>
            {{ content.title ?? "..."}} 
        </div>
        <div>
            <RiMoreFill size="25" className="my-icon" />
        </div>
    </div>
</template>

<script lang="ts" setup>
import { RiMoreFill } from '@remixicon/vue';
import { useContentStore } from '../store/content';
const content = useContentStore();
   
</script>

<style lang="scss" scoped>

</style>