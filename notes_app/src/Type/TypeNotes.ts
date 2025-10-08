// types/note.ts
export default interface TypeNotes {
  id: string;
  title: string;
  content: string;
  createdAt?: string; // optional field
}
export default interface Filter {
  search?: string;
  page?: number,
  record?:number,
}
