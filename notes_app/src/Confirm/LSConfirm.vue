<template>
   <v-dialog max-width="280" v-model="isShowPopup">
    <template v-slot:default="{ isActive }">
        <v-card title="Confirm">
        <v-card-text>
            {{ typeConfirm=="create"?"Are you sure you want to create new notes?":"Are you sure you want to delete this notes?" }}
        </v-card-text>

        <v-card-actions class="!pr-4 !pb-4">
            <div class="flex justify-end gap-x-2">
                    <div class="bg-green-400 px-4 py-2 rounded-lg text-white cursor-pointer" @click="onClickButtonSave">Save</div>
                             <div class="bg-gray-200 px-4 py-2 rounded-lg text-black cursor-pointer" @click="()=>{isShowPopup=false
                            }">Cancel</div>
                        </div>
        </v-card-actions>
        </v-card>
    </template>
</v-dialog>
</template>

<script lang="ts" setup>
import { ref } from 'vue';
    const props = defineProps<{
        type: string
    }>()    
    const typeConfirm = ref<string>(props.type);
    const  isShowPopup = defineModel<boolean>();
    const emit  = defineEmits<{
        (e: 'confirm', value: boolean): void,
        (e: 'cancel', value: boolean): void,
    }>();
    const onClickButtonSave=()=>{
        isShowPopup.value = false;
        console.log("Clicked Save button");
        emit('confirm',true);
    }
</script>

<style lang="scss" scoped>

</style>