import csv
import xlsxwriter 
# Workbook() takes one, non-optional, argument
# which is the filename that we want to create.
workbook = xlsxwriter.Workbook('/Users/miguelpedroso/Desktop/resultados/exp5_3.xlsx')
 
# The workbook object is then used to add new
# worksheet via the add_worksheet() method.
worksheet = workbook.add_worksheet()
r = 0
column = 0
# Use the worksheet object to write
# data via the write() method.

# Finally, close the Excel file
# via the close() method.


file = open('/Users/miguelpedroso/Desktop/resultados/GapRoad-2022-20-5-20-48-15-crossProb-0,9-elite-2-mutProb-0,05-tournamenteSize-2/EvolutionLog3.csv','r')
csvreader = csv.reader(file)
header = []
header = next(csvreader)
rows = []
for row in csvreader:
        rows.append(row)
for row in rows:
    for i in range (8):
        print(row[i])
        worksheet.write(column, r, row[i])
        r += 1
    column += 1
    r = 0

file.close()
workbook.close()

