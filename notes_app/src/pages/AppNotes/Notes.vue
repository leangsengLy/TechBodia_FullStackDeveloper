<template>
    <div class="grid transition-all ease-linear" :class="[ui.isCloseCollapse ? 'grid-cols-[50px_1fr]' : 'grid-cols-[250px_1fr]']">
        <div class="h-screen border-r bg-[#000000] py-4 px-3 overflow-hidden">
            <div class="flex justify-between">
                <p class="text-white font-bold" v-if="!ui.isCloseCollapse">Your Notes</p>
                <RiArrowLeftSFill size="25" class="text-white my-icon cursor-pointer" v-if="!ui.isCloseCollapse" @click="onCLickCloseNavLeft"/>
                <RiArrowRightSFill size="25" class="text-white my-icon cursor-pointer" v-else @click="onCLickCloseNavLeft"/>
            </div>
            <div class="mt-4 grid grid-rows-[1fr_80px] h-full">
                <div class="flex flex-col gap-y-2 flex-nowrap " :class="ui.isCloseCollapse?` w-[36px] `:``">
                    <div v-for="item in content.list" :class="[content.notes.title==item.title?'text-green-400 font-bold':'text-white']" class=" cursor-pointer  items-center flex gap-x-2" @click="selectContentTitle(item)">
                        <RiFileTextLine size="14"/>
                        <div class="text-[13px] whitespace-nowrap truncate-text " >{{ item.title }}</div>
                    </div>
                    <Button label="Check" icon="pi pi-check" />
                </div>
               <!-- <div>
                 <input type="text" v-if="!isShowTitle" v-model="title" placeholder="Your Title..." @keydown="onEnter" class="outline-none bg-[#a0a0a000] w-full h-[40px] text-white border-b-2"/>
                 <div :class="[content.title==title?'text-green-400 font-bold':'text-white']" class="cursor-pointer truncated-text" @click="selectContentTitle(title)" v-else>{{ title }}</div>
               </div> -->
               <div class="flex text-white text-[14px] gap-x-2 border cursor-pointer justify-center items-center rounded-lg h-[35px] " @click="addNewNotes">
                   <RiAddCircleLine size="17"/> 
                   <p v-if="!ui.isCloseCollapse"> Add new notes</p>
               </div>
            </div>
        </div>
        <div class="w-full h-screen grid grid-rows-[60px_1fr_100px]">
            <!-- {{ ui.isNavLeftOpen }} -->
            <SideHeaderContent/>
            <SideBodyContent/>
            <SideFooterContent/>
        </div>
    </div>
</template>

<script lang="ts" setup>
import { Ri24HoursFill, RiAddCircleFill, RiAddCircleLine, RiArrowLeftBoxFill, RiArrowLeftSFill, RiArrowRightSFill, RiFileTextLine } from '@remixicon/vue';
import SideBodyContent from '../../components/SideBodyContent.vue';
import SideFooterContent from '../../components/SideFooterContent.vue';
import SideHeaderContent from '../../components/SideHeaderContent.vue';
import { useCounterStore } from '../../store/counter';
import { useUIStore } from '../../store/ui_store';
import { onMounted, ref } from 'vue';
import { useContentStore } from '../../store/content';
import type Notes from "../../Type/TypeNotes";
import axios from 'axios';
const count = useCounterStore();
const ui = useUIStore();
const content = useContentStore();
const title = ref<string>("");
const error = ref<string>("");
const loading = ref<boolean>(false);
const notes = ref<Notes[]>();
const isShowTitle = ref<boolean>(false);
const selectContentTitle=(notes:Notes)=>{
    content.setNote(notes);
}
const onEnter=(event: KeyboardEvent)=>{
    if(event.key === "Enter"){
        console.log("Enter key pressed");
        count.increment();
        isShowTitle.value = true;
    }
}
const fetchNotes = async () => {
    try {
      const response = await axios.post("http://localhost:5246/api/notes/list", {});
      notes.value = response.data;
    } catch (err) {
      error.value = "Failed to fetch posts.";
      console.error(err);
    } finally {
      loading.value = false;
    }
  };
onMounted(async () => {
//   fetchNotes();
  content.getNotes();
});
const addNewNotes=()=>{
    console.log("add new notes");
    title.value = "";
    // isShowTitle.value = false;
}
const onCLickCloseNavLeft=()=>{
    console.log("close nav left");
    count.increment();
    ui.toggleNavLeft();
}
</script>

<style>
 .truncate-text {
  white-space: nowrap;      /* Prevents text from wrapping */
  overflow: hidden;         /* Hides the overflowed text */
  text-overflow: ellipsis;  /* Adds "..." at the end */
  width: 200px;             /* Required: set a width */
  display: block;           /* or inline-block / flex item */
}
</style>