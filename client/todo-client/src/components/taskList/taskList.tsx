import { ToDoTaskViewModel } from "../../models";
import { TaskCard } from "..";

type Props = {
  tasks: ToDoTaskViewModel[];
};

export const TasksList: React.FC<Props> = ({ tasks }) => {
  return (
    <div>
      {tasks.map((tsk: ToDoTaskViewModel) => (
        <TaskCard
          key={tsk.id}
          id={tsk.id}
          title={tsk.title}
          description={tsk.description}
          completeDueDate={tsk.completeDueDate}
          isCompleted={tsk.isCompleted}
          priorityId={tsk.priorityId}
        />
      ))}
    </div>
  );
};
