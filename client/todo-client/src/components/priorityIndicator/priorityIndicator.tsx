import "./priorityIndicator.scss";

interface priorityDescription {
  name: string;
  color: string;
}

const priorityMap: { [key: number]: priorityDescription } = {
  1: { name: "Low", color: "green" },
  2: { name: "Medium", color: "yellow" },
  3: { name: "High", color: "orange" },
  4: { name: "Critical", color: "red" },
};

const numberOfPriorirySteps = 4;

interface Props {
  priorityLevel: number;
}

const getSegments = (priorityLevel: number) => {
  if (priorityLevel > 0 && priorityLevel <= numberOfPriorirySteps) {
    const result = Array(numberOfPriorirySteps);
    const currentColor = priorityMap[priorityLevel].color;

    for (let i = 0; i < numberOfPriorirySteps; i++) {
      result[i] = (
        <div
          key={i}
          className={`segment ${currentColor} ${
            i < priorityLevel ? "filled" : ""
          }`}
        />
      );
    }

    return result;
  }

  return [];
};

export const PriorityIndicator: React.FC<Props> = ({ priorityLevel }) => {
  return (
    <div className="priority-indicator">
      <div className="bar">
        <div className="bar">{getSegments(priorityLevel)}</div>
      </div>
      <div className="label">
        {priorityMap[priorityLevel].name || "Unknown"}
      </div>
    </div>
  );
};
