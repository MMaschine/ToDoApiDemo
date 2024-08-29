import { Switch } from "@mui/material";
import { useState } from "react";
import { FaTable, FaList } from "react-icons/fa";
import "./viewToggle.scss";

type Props = {
  isTable: boolean;
  onChange: (status: boolean) => void;
};

export const ViewToggle: React.FC<Props> = (props) => {
  const [isTable, setIsTable] = useState(props.isTable);

  const handleToggle = (event: React.ChangeEvent<HTMLInputElement>) => {
    setIsTable(event.target.checked);
    props.onChange(event.target.checked);
  };

  return (
    <div className="view-type-container">
      <div className="switch-container">
        <Switch checked={props.isTable} onChange={handleToggle} />
        {isTable ? <FaTable className="icon" /> : <FaList className="icon" />}
      </div>
    </div>
  );
};
