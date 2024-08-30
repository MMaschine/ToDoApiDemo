import { ToDoTaskViewModel } from "../../models";
import { useState } from "react";
import { TasksTable, TasksList, ViewToggle } from "..";

type Props = {
  tasks: ToDoTaskViewModel[];
};

export const TasksForm: React.FC<Props> = (props) => {
  const [isTable, setIsTable] = useState(true);

  const handleViewChange = (status: boolean) => {
    setIsTable(status);
  };

  return (
    <div>
      <ViewToggle isTable={isTable} onChange={handleViewChange} />
      {isTable ? (
        <TasksTable tasks={props.tasks} />
      ) : (
        <TasksList tasks={props.tasks} />
      )}
    </div>
  );
};
