import { defineStore } from "pinia";
import axios from "axios";
export const useLoginStore = defineStore("login", {
    state:()=>({
        password:"" as string,
        email : {} as string
    }),
    actions:{
        async CreateSignUp(email:string,password:string,isLogin:boolean=false):Promise<any>{
            try {
                const response = await axios.post(`http://localhost:5246/api/login/${isLogin?'is_login_success':'register'}`, {
                    email: email,
                    password: password,
                });
                console.log(response)
                return response.data;
            } catch (err:any) {
                 console.log(err)
                return err.response;
            } finally {
                console.log("done");
            }
        },
       
    }
});