import { ToDoTaskViewModel } from "../../models";
import { TaskCard } from "../taskCard/taskCard";

type Props = {
  tasks: ToDoTaskViewModel[];
};

export const TasksForm: React.FC<Props> = (props) => {
  return (
    <div>
      {props.tasks.map((tsk: ToDoTaskViewModel) => (
        <TaskCard
          key={tsk.id}
          id={tsk.id}
          title={tsk.title}
          description={tsk.description}
          completeDueDate={tsk.completeDueDate}
          isCompleted={tsk.isCompleted}
        />
      ))}
    </div>
  );
};
