<template>
    <div class="h-[60px] w-full bg-[#f3f4f6] flex items-center justify-between px-6">
        <div class="font-bold text-[15px] flex gap-x-2 items-center">
          
            <div>{{ content.notes.title ?? "..."}} </div>
            <RiDeleteBinLine size="18" color="red" class="cursor-pointer" @click="onDeleteNotes" v-if="content.notes.title!=undefined"/>
        </div>
        <div>
            <RiMoreFill size="18" className="my-icon" />
        </div>
    </div>
</template>

<script lang="ts" setup>
import { RiDeleteBinLine, RiFileTextLine, RiMoreFill } from '@remixicon/vue';
import { useContentStore } from '../store/content';
const content = useContentStore();
const onDeleteNotes=()=>{
    content.deleteNotes();
}
</script>

<style lang="scss" scoped>

</style>