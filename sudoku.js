console.log(validSolution([
    [5, 3, 4, 6, 7, 8, 9, 1, 2],
    [6, 7, 2, 1, 9, 5, 3, 4, 8],
    [1, 9, 8, 3, 4, 2, 5, 6, 7],
    [8, 5, 9, 7, 6, 1, 4, 2, 3],
    [4, 2, 6, 8, 5, 3, 7, 9, 1],
    [7, 1, 3, 9, 2, 4, 8, 5, 6],
    [9, 6, 1, 5, 3, 7, 2, 8, 4],
    [2, 8, 7, 4, 1, 9, 6, 3, 5],
    [3, 4, 5, 2, 8, 6, 1, 7, 9]
])); // => true

console.log(validSolution([
    [5, 3, 4, 6, 7, 8, 9, 1, 2],
    [6, 7, 2, 1, 9, 0, 3, 4, 8],
    [1, 0, 0, 3, 4, 2, 5, 6, 0],
    [8, 5, 9, 7, 6, 1, 0, 2, 0],
    [4, 2, 6, 8, 5, 3, 7, 9, 1],
    [7, 1, 3, 9, 2, 4, 8, 5, 6],
    [9, 0, 1, 5, 3, 7, 2, 1, 4],
    [2, 8, 7, 4, 1, 9, 6, 3, 5],
    [3, 0, 0, 4, 8, 1, 1, 7, 9]
])); // => false

function validSolution(array) {
    let rows = [];
    let cols = [];
    let boxes = [];
    for (let i = 0; i < 9; i++)
    {
        rows.push([]);
        cols.push([]);
        boxes.push([]);
    }

    for (let i = 0; i < array.length; i++)
    {
        for (let j = 0; j < array.length; j++)
        {
            let cell = array[i][j];

            if (cell !== 0)
            {
                if (rows[i].includes(cell))
                {
                    return false;
                } else rows[i].push(cell);

                if (cols[j].includes(cell))
                {
                    return false;
                } else cols[j].push(cell);

                let boxIndex = Math.floor((i / 3)) * 3 + Math.floor(j / 3);

                if (boxes[boxIndex].includes(cell))
                {
                    return false
                } else boxes[boxIndex].push(cell);
            }
        }
    }
    return true;
}
