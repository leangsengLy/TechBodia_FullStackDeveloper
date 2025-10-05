<template>
    <div class="grid transition-all ease-linear" :class="[ui.isCloseCollapse ? 'grid-cols-[50px_1fr]' : 'grid-cols-[250px_1fr]']">
        <div class="h-screen border-r bg-[#000000] py-4 px-3 overflow-hidden">
            <div class="flex items-center justify-between flex-wrap">
                <!-- <p class="text-white font-bold" v-if="!ui.isCloseCollapse">Your Notes</p> -->
                <div class="flex gap-x-2 items-center">
                    <img :src="LogoTechbo" alt="No Image" class=" rounded-full" :class="ui.isCloseCollapse?'w-[30px] h-[30px]':' w-[43px] h-[43px] '"/>
                    <div>
                        <p class="text-white" v-if="!ui.isCloseCollapse">TechBodia</p>
                        <p class="text-[#ffffff89] text-[13px]" v-if="!ui.isCloseCollapse">Software in cambodia</p>
                    </div>
                </div>
                <RiArrowLeftSFill size="25" class="text-white my-icon cursor-pointer" v-if="!ui.isCloseCollapse" @click="onCLickCloseNavLeft"/>
                <RiArrowRightSFill size="25" class="text-white my-icon cursor-pointer" v-else @click="onCLickCloseNavLeft"/>
            </div>
            <div class="mt-4 grid grid-rows-[1fr_110px] h-full">
                <div class="flex flex-col overflow-y-auto gap-y-2 flex-nowrap " :class="ui.isCloseCollapse?` w-[36px] `:``">
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
                 <v-dialog max-width="500" v-model="isShowPopup">
                    <template v-slot:activator="{ props: TestShow  }">
                         <div v-bind="TestShow" class="flex text-white hover:opacity-70 text-[14px] gap-x-2 border cursor-pointer justify-center items-center rounded-lg h-[42px] " @click="addNewNotes">
                            <RiAddCircleLine size="17"/> 
                            <p v-if="!ui.isCloseCollapse"> Add new notes</p>
                        </div>
                    </template>

                    <template v-slot:default="{ TestShow }">
                         <div class="bg-white p-5 flex flex-col gap-y-4 rounded-lg">
                        <h3 class="text-lg font-bold">New Notes</h3>    
                            <v-text-field clearable @click:clear="onClearTitle" autofocus ref="myInput"  @keydown="handleKeydown"  persistent-clear label="Title" hint="Enter your title notes here." v-model="title" variant="outlined"></v-text-field>
                        <div class="flex justify-end gap-x-2">
                            <div class="bg-green-400 px-4 py-2 rounded-lg text-white cursor-pointer" @click="()=>{isShowPopup=false
                                AddNewTitle()
                            }">Save</div>

                             <div class="bg-gray-200 px-4 py-2 rounded-lg text-black cursor-pointer" @click="()=>{isShowPopup=false
                            }">Cancel</div>
                        </div>
                         </div>
                    </template>
                </v-dialog>
               
            </div>
        </div>
        <div class="w-full h-screen grid grid-rows-[60px_1fr_100px]">
            <!-- {{ ui.isNavLeftOpen }} -->
            <SideHeaderContent/>
            <SideBodyContent/>
            <SideFooterContent/>
        </div>
           <v-snackbar
            color="success"
            v-model="isSuccess"
        >
            {{ msg }}
            <template v-slot:actions>
                <v-btn
                color="pink"
                variant="text"
                @click="isSuccess = false"
                >
                Close
                </v-btn>
            </template>
        </v-snackbar>
    </div>
</template>

<script lang="ts" setup>
import { Ri24HoursFill, RiAddCircleFill, RiAddCircleLine, RiArrowLeftBoxFill, RiArrowLeftSFill, RiArrowRightSFill, RiFileTextLine } from '@remixicon/vue';
import SideBodyContent from '../../components/SideBodyContent.vue';
import SideFooterContent from '../../components/SideFooterContent.vue';
import SideHeaderContent from '../../components/SideHeaderContent.vue';
import { useCounterStore } from '../../store/counter';
import { useUIStore } from '../../store/ui_store';
import { onMounted, ref, type HtmlHTMLAttributes } from 'vue';
import LogoTechbo from '../../assets/Tecobodia_logo.jpg';
import { useContentStore } from '../../store/content';
import type Notes from "../../Type/TypeNotes";
import axios from 'axios';
const count = useCounterStore();
const ui = useUIStore();
const content = useContentStore();
const myInput = ref(null);
const isShowPopup = ref<boolean>(false);
const isSuccess = ref<boolean>();
const title = ref<string>("");
const error = ref<string>("");
const msg = ref<string>("");
const loading = ref<boolean>(false);
const notes = ref<Notes[]>();
const isShowTitle = ref<boolean>(false);
const selectContentTitle=(notes:Notes)=>{
    content.setNote(notes);
}
const AddNewTitle=async()=>{
    isSuccess.value = await content.setTitle(title.value);
    msg.value = getMessage(isSuccess.value);
    isShowPopup.value = false;
}
const getMessage = (isSuccess:boolean):string=>{
    return isSuccess?"Create noted successfully":"Fail to create notes.";
}
const handleKeydown = async (event:KeyboardEvent)=>{
    if(event.key === "Enter" && title.value!==""){
         isShowPopup.value = false;
        isSuccess.value = await content.setTitle(title.value);
        msg.value = getMessage(isSuccess.value);
    }

}
const onEnter=(event: KeyboardEvent)=>{
    if(event.key === "Enter"){
        console.log("Enter key pressed");
        count.increment();
        isShowTitle.value = true;
    }
}
const onClearTitle=()=>{
    title.value = "";
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
    isShowPopup.value = true;
    title.value = "";
    setTimeout(() => {
       console.log(myInput.value.focus());
    }, 100);    
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