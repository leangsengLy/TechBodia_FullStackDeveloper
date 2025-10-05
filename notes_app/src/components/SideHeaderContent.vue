<template>
    <div class="h-[60px] w-full bg-[#f3f4f6] flex items-center justify-between px-6">
        <div class="font-bold text-[15px] flex gap-x-2 items-center">
          
            <div>{{ content.notes.title ?? "..."}} </div>
            <RiDeleteBinLine size="18" color="red" class="cursor-pointer" @click="onDeleteNotes" v-if="content.notes.title!=undefined"/>
        </div>
        <div>
            <RiMoreFill size="18" className="my-icon" />
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
                @click="snackbar = false"
                >
                Close
                </v-btn>
            </template>
        </v-snackbar>
    </div>
</template>

<script lang="ts" setup>
import { RiDeleteBinLine, RiMoreFill } from '@remixicon/vue';
import { useContentStore } from '../store/content';
import { ref } from 'vue';
const msg = ref<string>("");
const isSuccess = ref<boolean>(false);
const content = useContentStore();
const onDeleteNotes=async()=>{
    isSuccess.value = await content.deleteNotes();
    if(isSuccess) msg.value = "Notes deleted successfully!";
    else msg.value = "Failed to delete notes.";
}
const snackbar = ref<boolean>(true);
</script>

<style lang="scss" scoped>

</style>