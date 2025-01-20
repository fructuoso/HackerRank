students = []

if __name__ == '__main__':
    for _ in range(int(input())):
        name = input()
        score = float(input())
        students.append([name, score])

    scores = map(lambda x: x[1], students)
    second_lowest = sorted(list(set(scores)))[1]
    students_with_second_lowest = filter(lambda x: x[1] == second_lowest, students)
    names_of_students_with_second_lowest = map(lambda x: x[0], students_with_second_lowest)

    for name in sorted(names_of_students_with_second_lowest):
        print(name)
