import "./tasksTable.scss";
import { ToDoTaskViewModel } from "../../models";
import { formatDate } from "../../helpers";

type Props = {
  tasks: ToDoTaskViewModel[];
};

export const TasksTable: React.FC<Props> = ({ tasks }) => {
  return (
    <table className="custom-table">
      <thead>
        <tr>
          <th>Title</th>
          <th>Description</th>
          <th>Complete before</th>
          <th>Status</th>
          <th>Priority</th>
          <th>Created</th>
          <th>Last modified</th>
        </tr>
      </thead>
      <tbody>
        {tasks.map((task) => (
          <tr key={task.id}>
            <td>{task.title}</td>
            <td>{task.description}</td>
            <td>{formatDate(task.completeDueDate)}</td>
            <td>{task.isCompleted ? "Completed" : "Not completed"}</td>
            <td>{task.priorityId}</td>
            <td>{formatDate(task.createdDate)}</td>
            <td>{formatDate(task.lastModifiedDate)}</td>
          </tr>
        ))}
      </tbody>
    </table>
  );
};
