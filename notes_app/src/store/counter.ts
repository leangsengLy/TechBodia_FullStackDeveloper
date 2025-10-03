import { defineStore } from "pinia";
export const useCounterStore = defineStore("counter", {
    state:()=>({
        count:0 as number,
        name:"" as string,
        isLoggedIn:false as boolean,
        User:{name:"",Email:"",Password:""} as {name:string,Email:string,Password:string}
    }),
    actions:{
        increment(){
            this.count++
        }
    }
});