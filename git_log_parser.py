import sys
import pandas as pd

# Read data from stdin into a DataFrame
df = pd.read_csv(sys.stdin, sep='\t', header=None, names=['additions', 'deletions', 'filename'])

# Convert "additions" column to float
df['additions'] = df['additions'].astype(float)

# Perform division and print result
print(f'Total size: {df["additions"].sum()/1e6:.2f} MB')
