import "./App.css";
import { TasksForm } from "./components/tasksForm/tasksForm";
import { useTasks } from "./hooks/useTasks";
import taskSymbol from "./icons/taskSymbol.svg";

function App() {
  const { data: tasks, status, error } = useTasks();

  if (status === "loading") return <div>Loading...</div>;
  if (status === "error")
    return (
      <div>
        Error: {error instanceof Error ? error.message : "An error occurred"}
      </div>
    );

  return (
    <div>
      <h1>
        {<img width={40} height={40} src={taskSymbol} alt="" />} ToDo Tasks
      </h1>
      <TasksForm tasks={tasks ?? []} />
    </div>
  );
}

export default App;
