<template>
     <v-snackbar
            color="success"
            v-model="isShowSnackbar"
        >
            {{ message }}
            <template v-slot:actions>
                <v-btn
                color="pink"
                variant="text"
                @click="isShowSnackbar = false"
                >
                Close
                </v-btn>
            </template>
        </v-snackbar>
</template>

<script lang="ts" setup>
import { ref, watch } from 'vue';
    const props = defineProps<{
        isSuccess: boolean,
        msg: string,
        snackbar?: boolean
    }>()
    const isShowSnackbar = defineModel<boolean>();
    const message = ref<string>(props.msg);
    const isSuccessStatus = ref<boolean>(props.isSuccess);
    watch(isShowSnackbar,()=>{
        console.log(isSuccessStatus.value)
        if(isSuccessStatus.value) message.value = "Successfuly";
        else message.value="Fail";
    })
</script>

<style lang="scss" scoped>

</style>