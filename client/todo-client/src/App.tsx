import "./App.scss";
import { TasksForm } from "./components";
import { useTasks } from "./hooks";
import taskSymbol from "./icons/taskSymbol.svg";

function App() {
  const { data: tasks, status, error } = useTasks();

  if (status === "loading") return <div>Loading...</div>;
  if (status === "error")
    return (
      <div className="error-message">
        Error: {error instanceof Error ? error.message : "An error occurred"}
      </div>
    );

  return (
    <div>
      <div className="icon-header">
        <img className="icon" src={taskSymbol} alt="" />
        <h1> ToDo Tasks</h1>
      </div>
      <TasksForm tasks={tasks ?? []} />
    </div>
  );
}

export default App;
