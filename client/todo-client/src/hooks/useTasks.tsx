import { useQuery } from "react-query";
import axios from "axios";
import { ToDoTaskViewModel } from "../models";

const getTasks = async (): Promise<ToDoTaskViewModel[]> => {
  const response = await axios.get<ToDoTaskViewModel[]>(
    "http://localhost:5242/api/Tasks"
  );
  return response.data;
};

export const useTasks = () => {
  return useQuery("tasks", getTasks);
};
