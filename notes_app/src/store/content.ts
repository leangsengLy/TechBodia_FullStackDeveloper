import { defineStore } from "pinia";
export const useContentStore = defineStore("content", {
    state:()=>({
        title:"" as string,
    }),
    actions:{
        selectContent(title:string):void{
            console.log("get title",title)
            this.title = title;
        }
    }
});