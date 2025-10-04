<template>
    <div class=" px-[25px] py-[20px]">
        <div class="w-full h-full bg-[#9696961f] rounded-[10px] flex items-center justify-center" >
            <input type="text" @keydown="onKeyDownEnter" v-model="title" @focus="onFocusInput" :readonly="content.notes.title==undefined" placeholder="Type something..."  :class="[content.notes.title!==undefined ? 'cursor-text' : 'cursor-not-allowed']" class="w-full h-full  bg-[#dfdfdf00] outline-none rounded-[10px] pl-3"/>
        </div>
    </div>
</template>

<script lang="ts" setup>
import { ref, watch } from 'vue';
import { useContentStore } from '../store/content';
 const content = useContentStore();
 const title = ref<string>("");
const onFocusInput=(event: FocusEvent)=>{
    if(content.notes.title!==undefined){
        title.value = content.notes.content ?? "";
    }
}
const onKeyDownEnter=(event: KeyboardEvent)=>{
    if(event.key === "Enter" && content.notes.title!==undefined){
        content.changeContent(content.notes.id,title.value);
        title.value = "";
        content.UpdateNotes();
    }
}
watch(content,()=>{
    title.value =  "";
})
   
</script>

<style lang="scss" scoped>

</style>