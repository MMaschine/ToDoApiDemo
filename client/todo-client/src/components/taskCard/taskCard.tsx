import React from "react";
import dayjs from 'dayjs';
import './taskCard.scss'
import { FaCheckCircle, FaHourglassHalf,FaCalendarAlt  } from 'react-icons/fa';

type Props = {
    id: number
    title: string,
    description: string,
    completeDueDate : Date,
    isCompleted: boolean
};

export const TaskCard : React.FC<Props> = (props)=> {
const {title, description, completeDueDate, isCompleted} = props

const taskContainerClass = `task-container ${isCompleted ? 'completed' : 'not-completed'}`;
const statusClass = `status ${isCompleted ? 'completed' : 'not-completed'}`;
const statusIcon = isCompleted ? <FaCheckCircle className="status-icon" /> : <FaHourglassHalf className="status-icon" />;
const statusText = isCompleted ? "Task completed" : "Not completed yet";

return (
  <div className={taskContainerClass}>
    <h1>{title}</h1>
    <p className="description">{description !== '' ? description : "---"}</p>
    <p><FaCalendarAlt/> Complete due date: {dayjs(completeDueDate).format("YYYY-MM-DD")}</p>
    <p  className={statusClass}>
     {statusText} {statusIcon}
    </p>
  </div>)  
};