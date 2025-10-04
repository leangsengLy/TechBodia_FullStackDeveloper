import { defineStore } from "pinia";
import type Note from "../Type/TypeNotes";
import axios from "axios";
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
        async getNotes(){
            try {
            const response = await axios.post("http://localhost:5246/api/notes/list", {});
                this.list = response.data;
                console.log(this.list);
            } catch (err) {
                console.error(err);
            } finally {
                console.log("done");
            }
        },
        async deleteNotes(){
            try {
            const response = await axios.get(`http://localhost:5246/api/notes/delete?id=${this.notes.id}`);
                this.list = response.data;
                this.notes={} as Note;
                this.getNotes();
            } catch (err) {
                console.error(err);
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