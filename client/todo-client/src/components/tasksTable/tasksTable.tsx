import dayjs from "dayjs";
import { ToDoTaskViewModel } from "../../models/toDoTaskViewModel";
import "./tasksTable.scss";

type Props = {
  tasks: ToDoTaskViewModel[];
};

export const TasksTable: React.FC<Props> = (props) => {
  return (
    <table className="custom-table">
      <thead>
        <tr>
          <th>Title</th>
          <th>Description</th>
          <th>Complete before</th>
          <th>Status</th>
          <th>Priority</th>
        </tr>
      </thead>
      <tbody>
        {props.tasks.map((task) => (
          <tr key={task.id}>
            <td>{task.title}</td>
            <td>{task.description}</td>
            <td>{dayjs(task.completeDueDate).format("YYYY-MM-DD")}</td>
            <td>{task.isCompleted ? "Completed" : "Not completed"}</td>
            <td>{task.priorityId}</td>
          </tr>
        ))}
      </tbody>
    </table>
  );
};
