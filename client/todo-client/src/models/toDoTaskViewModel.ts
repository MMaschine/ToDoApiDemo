export type ToDoTaskViewModel = {
        id : number,
        title:string,
        description:string,
        completeDueDate:Date,
        isCompleted:boolean,
        priorityId:number,
        assignedUserId:number
}