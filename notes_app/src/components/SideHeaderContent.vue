<template>
    <div class="h-[60px] w-full bg-[#f3f4f6] flex items-center justify-between px-6">
        <div class=" text-[15px] flex gap-x-3 items-start">
          
            <div>
                <p class="font-bold">{{ content.notes.title ?? "..."}}</p>
                <p class="text-[12px]" v-if="content.notes.title!=undefined">{{ moment().format('MMMM DD, YYYY') }}</p> 
            </div>
             <RiDeleteBinLine size="14" color="red" class="cursor-pointer mt-1" @click="onDeleteNotes" v-if="content.notes.title!=undefined"/>
           
           
        </div>
        <div>
              <RiLogoutCircleRLine size="18" class="cursor-pointer" @click="onLogout" />
        </div>
        <v-snackbar
            color="success"
            v-model="isSuccess"
        >
            {{ msg }}
            <!-- <template v-slot:actions>
                <v-btn
                color="pink"
                variant="text"
                @click="snackbar = false"
                >
                Close
                </v-btn>
            </template> -->
        </v-snackbar>
        <LSConfirm v-model="isShowConfirm" type="delete" @confirm="onConfirmOk"/> 
    </div>
</template>

<script lang="ts" setup>
import { RiDeleteBinLine, RiLogoutCircleRLine, RiMoreFill } from '@remixicon/vue';
import { useContentStore } from '../store/content';
import { ref } from 'vue';
import LSConfirm from '../Confirm/LSConfirm.vue';
import moment from 'moment';
import { useRoute, useRouter } from 'vue-router';
const msg = ref<string>("");
const isSuccess = ref<boolean>(false);
const isShowConfirm = ref<boolean>(false);
const content = useContentStore();
  const router = useRouter()
const onLogout=()=>{
    deleteCookie("token");
    router.push('/login')
}
const deleteCookie=(name:string, path = '/')=> {
  document.cookie = name + '=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=' + path + ';';
}
const onDeleteNotes=async()=>{
    isShowConfirm.value = true;
    // isSuccess.value = await content.deleteNotes();
    // if(isSuccess) msg.value = "Notes deleted successfully!";
    // else msg.value = "Failed to delete notes.";
}
const onConfirmOk=()=>{
    isShowConfirm.value = false;
    setTimeout(async()=>{
        isSuccess.value = await content.deleteNotes();
        if(isSuccess.value) msg.value = "Notes deleted successfully!";
        else msg.value = "Failed to delete notes.";
    },100)
}
const snackbar = ref<boolean>(true);
</script>

<style lang="scss" scoped>

</style>