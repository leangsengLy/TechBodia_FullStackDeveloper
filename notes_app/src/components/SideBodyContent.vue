<template>
    <div class="flex  " :class="[content.notes.content==undefined || content.notes.content=='' ? 'justify-center items-center' : 'p-5 overflow-y-auto']">
        <EmptyNotes v-if="content.notes.content==undefined || content.notes.content==''"/>
        <div v-else>
            {{ content.notes.content }}
        </div>
    </div>
</template>

<script lang="ts" setup>
import { useContentStore } from '../store/content';
import EmptyNotes from './EmptyNotes.vue';
const content = useContentStore();
</script>

<style lang="scss" scoped>

</style>