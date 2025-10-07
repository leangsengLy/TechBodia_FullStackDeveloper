import { defineStore } from "pinia";
import type Note from "../Type/TypeNotes";
import axios from "axios";
import { LSGetCookie } from "../ultil/LSGlobal";
export const useContentStore = defineStore("content", {
    state:()=>({
        title:"" as string,
        notes : {} as Note,
        list :[] as Note[]
    }),
    actions:{
        selectContent(title:string):void{
            this.title = title;
        },
        setNote(notes:Note):void{
            this.notes=notes;
        },
        changeContent(id:string,content:string):void{
            var note = this.list.find((note:Note) => note.id === id);
             if (note) {
                note.content = content;
            }
        },
        async getNotes(isCreate:boolean=false):Promise<any>{
            try {
            const response = await axios.post("http://localhost:5246/api/notes/list", {},

                {
                    headers: {
                        "Authorization": `Bearer ${LSGetCookie("token")}`, // attach token
                        "Content-Type": "application/json",
                    },
                }
            );
                this.list = response.data as Note[];
                if(isCreate && this.list.length>0) this.notes = this.list[0] as Note;
                console.log(this.list);
            } catch (err:any) {
                console.log(err);
                let msg = "";
                if (err.code === "ERR_NETWORK") {
                    msg="Network error — server unreachable or CORS issue";
                }
                return msg;
            } finally {
                console.log("done");
            }
        },
        async setTitle(title:string):Promise<boolean>{
            try {
            const response = await axios.post("http://localhost:5246/api/notes/create", {
                title: title,
                content: "",
            },
             {
                    headers: {
                        "Authorization": `Bearer ${LSGetCookie("token")}`, // attach token
                        "Content-Type": "application/json",
                    },
                }
        );
                // this.list = response.data;
                this.getNotes(true);
                return true;
            } catch (err) {
                console.error(err);
                return false;
            } finally {
                console.log("done");
            }
        },
        async deleteNotes():Promise<boolean>{ 
            try {
            const response = await axios.get(`http://localhost:5246/api/notes/delete?id=${this.notes.id}`, {
                    headers: {
                        "Authorization": `Bearer ${LSGetCookie("token")}`, // attach token
                        "Content-Type": "application/json",
                    },
                });
                this.list = response.data;
                this.notes={} as Note;
                this.getNotes(true);
                return true;
            } catch (err) {
                console.error(err);
                  return false;
            } finally {
                console.log("done");
            }
        },
         async UpdateNotes(){
            try {
            await axios.post(`http://localhost:5246/api/notes/update`,{
                id: this.notes.id,
                title: this.notes.title,
                content: this.notes.content,
            });
            } catch (err) {
                console.error(err);
            } finally {
                console.log("done");
            }
        }
    }
});