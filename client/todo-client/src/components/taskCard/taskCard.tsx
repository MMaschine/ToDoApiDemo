import React from "react";
import "./taskCard.scss";
import { FaCheckCircle, FaHourglassHalf, FaCalendarAlt } from "react-icons/fa";
import { PriorityIndicator } from "..";
import { formatDate } from "../../helpers";

type Props = {
  id: number;
  title: string;
  description: string;
  completeDueDate: Date;
  isCompleted: boolean;
  priorityId: number;
};

export const TaskCard: React.FC<Props> = ({
  title,
  description,
  completeDueDate,
  isCompleted,
  priorityId,
}) => {
  const taskContainerClass = `task-container ${
    isCompleted ? "completed" : "not-completed"
  }`;

  const statusClass = `status ${isCompleted ? "completed" : "not-completed"}`;

  const statusIcon = isCompleted ? (
    <FaCheckCircle className="status-icon" />
  ) : (
    <FaHourglassHalf className="status-icon" />
  );

  const statusText = isCompleted ? "Task completed" : "Not completed yet";

  return (
    <div className={taskContainerClass}>
      <h1>{title}</h1>
      <p className="description">{description !== "" ? description : "---"}</p>
      <PriorityIndicator priorityLevel={priorityId} />
      <p>
        <FaCalendarAlt /> Deadline: {formatDate(completeDueDate)}
      </p>
      <p className={statusClass}>
        {statusText} {statusIcon}
      </p>
    </div>
  );
};
