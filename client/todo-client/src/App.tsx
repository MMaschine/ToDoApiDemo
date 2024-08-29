import "./App.css";
import { TasksForm } from "./components/tasksForm/tasksForm";
import { useTasks } from "./hooks/useTasks";

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
      <h1>ToDo tasks demo</h1>
      <TasksForm tasks={tasks ?? []} />
    </div>
  );
}

export default App;
