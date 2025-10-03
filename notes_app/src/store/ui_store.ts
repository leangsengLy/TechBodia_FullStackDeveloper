import { defineStore } from "pinia";
export const useUIStore = defineStore("ui", {
    state:()=>({
        isCloseCollapse:false as boolean,
    }),
    actions:{
        toggleNavLeft(){
            this.isCloseCollapse = !this.isCloseCollapse;
        },
        closeNavLeft(){
            this.isCloseCollapse = false;
        },
        openNavLeft(){
            this.isCloseCollapse = true;
        }
    }
});