import { useQuery } from "react-query";
import axios from "axios";
import { ToDoTaskViewModel } from "../models";
import { API_BASE_URL } from "../config";

const getTasks = async (): Promise<ToDoTaskViewModel[]> => {
  const response = await axios.get<ToDoTaskViewModel[]>(
    `${API_BASE_URL}/api/Tasks`
  );
  return response.data;
};

export const useTasks = () => {
  return useQuery("tasks", getTasks);
};
