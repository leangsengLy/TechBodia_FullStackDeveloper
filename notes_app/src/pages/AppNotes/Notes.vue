<template>
    <div class="grid transition-all ease-linear" :class="[ui.isCloseCollapse ? 'grid-cols-[50px_1fr]' : 'grid-cols-[250px_1fr]']">
        <div class="h-screen border-r bg-[#000000] py-4 px-3 overflow-hidden">
            <div class="flex justify-between">
                <p class="text-white font-bold" v-if="!ui.isCloseCollapse">Your Notes</p>
                <RiArrowLeftSFill size="25" class="text-white my-icon cursor-pointer" v-if="!ui.isCloseCollapse" @click="onCLickCloseNavLeft"/>
                <RiArrowRightSFill size="25" class="text-white my-icon cursor-pointer" v-else @click="onCLickCloseNavLeft"/>
            </div>
            <div class="mt-4">
                <input type="text" v-if="!isShowTitle" v-model="title" placeholder="Your Title..." @keydown="onEnter" class="outline-none bg-[#a0a0a000] w-full h-[40px] text-white border-b-2"/>
                <div :class="[content.title==title?'text-green-400 font-bold':'text-white']" class="cursor-pointer truncated-text" @click="selectContentTitle(title)" v-else>{{ title }}</div>
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
import { Ri24HoursFill, RiArrowLeftBoxFill, RiArrowLeftSFill, RiArrowRightSFill } from '@remixicon/vue';
import SideBodyContent from '../../components/SideBodyContent.vue';
import SideFooterContent from '../../components/SideFooterContent.vue';
import SideHeaderContent from '../../components/SideHeaderContent.vue';
import { useCounterStore } from '../../store/counter';
import { useUIStore } from '../../store/ui_store';
import { ref } from 'vue';
import { useContentStore } from '../../store/content';
const count = useCounterStore();
const ui = useUIStore();
const content = useContentStore();
const title = ref<string>("");
const isShowTitle = ref<boolean>(false);
const selectContentTitle=(title:string)=>{
    console.log("select content title:", title);
    content.selectContent(title);
}
const onEnter=(event: KeyboardEvent)=>{
    if(event.key === "Enter"){
        console.log("Enter key pressed");
        count.increment();
        isShowTitle.value = true;
    }
}
const onCLickCloseNavLeft=()=>{
    console.log("close nav left");
    count.increment();
    ui.toggleNavLeft();
}
</script>

<style>
.truncated-text {
  white-space: nowrap;
  overflow: hidden;
  text-overflow: ellipsis;
  width: 200px; /* Example width for the container */
}
</style>